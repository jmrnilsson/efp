'use strict';

const electron = require('electron');
const app = electron.app;
const BrowserWindow = electron.BrowserWindow;
const ipcMain = require('electron').ipcMain;
const fs = require('fs');
const exec = require('child_process').exec;

let mainWindow;

function createWindow() {
    mainWindow = new BrowserWindow({width: 900, height: 800});
    mainWindow.loadURL(`file://${__dirname}/index.html`);
    mainWindow.webContents.openDevTools();
    mainWindow.on('closed', () => { mainWindow = null; });
}

app.on('ready', createWindow);
app.on('window-all-closed', () => { if (process.platform !== 'darwin') app.quit(); });

app.on('activate', () => { if (mainWindow === null) createWindow(); });

ipcMain.on('go', (event, arg) => {
    fs.writeFile('./dotnet/P0.cs', arg.replace(/\&gt;/g, '>'), (err) => {
        if (err) throw err;
        exec('(cd dotnet; dnx run)', (error, stdout, stderr) => {
            if (stderr) throw Error(stderr);
            console.log(stderr);
            console.log('Publishing result..');
            event.sender.send('on-result', JSON.parse(stdout));
        });
    });
});

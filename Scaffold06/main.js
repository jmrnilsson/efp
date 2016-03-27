'use strict';

const electron = require('electron');
const app = electron.app;
const BrowserWindow = electron.BrowserWindow;
const ipc = require('electron').ipcMain;
const fs = require('fs');
const exec = require('child_process').exec;

let mainWindow;

function createWindow() {
    if (mainWindow === null) {
        createWindow();
    }
    mainWindow = new BrowserWindow({width: 900, height: 800});
    mainWindow.loadURL(`file://${__dirname}/index.html`);
    mainWindow.on('closed', () => { mainWindow = null; });
}

app.on('ready', createWindow);
app.on('window-all-closed', () => { if (process.platform !== 'darwin') app.quit(); });
app.on('activate', createWindow);

ipc.on('go', (event, arg) => {
    fs.writeFile('./dotnet/P0.cs', arg.replace(/\&gt;/g, '>'), (err) => {
        if (err) throw err;
        exec('(cd dotnet; dnx run)', (error, stdout, stderr) => {
            if (stderr) throw Error(stderr);
            console.log('Publishing result..');
            event.sender.send('on-result', JSON.parse(stdout));
        });
    });
});

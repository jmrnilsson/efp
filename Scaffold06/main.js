'use strict';

const electron = require('electron');
const app = electron.app;
const BrowserWindow = electron.BrowserWindow;
const ipcMain = require('electron').ipcMain;
const fs = require('fs');
const exec = require('child_process').exec;

let mainWindow;

function createWindow () {
    mainWindow = new BrowserWindow({width: 900, height: 800});
    mainWindow.loadURL('file://' + __dirname + '/index.html');
    mainWindow.webContents.openDevTools();

  mainWindow.on('closed', function() {
    mainWindow = null;
  });
}

app.on('ready', createWindow);
app.on('window-all-closed', function () {
    if (process.platform !== 'darwin') {
        app.quit();
    }
});

app.on('activate', function () {
    if (mainWindow === null) {
        createWindow();
    }
});

ipcMain.on('go', function(event, arg) {
    let lines = JSON.stringify(arg).replace(/"/g, '').trim().split('\\n');
    lines.forEach(line => console.log(line));
    console.log('Saved..');

    fs.writeFile('./dotnet/P0.cs', arg.replace(/\&gt;/g, '>'), (err) => {
    if (err) throw err;
        console.log('Execute process..');
        exec('(cd dotnet; dnx run)', function callback(error, stdout, stderr){
            if (stderr) {
                console.log(stderr);
            }
            console.log(stderr);
            console.log('Publishing result..');
            event.sender.send('on-result', JSON.parse(stdout));
        });
    });
});

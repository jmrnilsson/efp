'use strict';

const electron = require('electron');
// Module to control application life.
const app = electron.app;
// Module to create native browser window.
const BrowserWindow = electron.BrowserWindow;
const ipcMain = require('electron').ipcMain;
const fs = require('fs');
const exec = require('child_process').exec;

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mainWindow;

function createWindow () {
    mainWindow = new BrowserWindow({width: 1200, height: 600});
    mainWindow.loadURL('file://' + __dirname + '/index.html');
    mainWindow.webContents.openDevTools();

  mainWindow.on('closed', function() {
    // Dereference the window object, usually you would store windows
    // in an array if your app supports multi windows.
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

ipcMain.on('my-msg', function(event, arg) {
    let lines = JSON.stringify(arg).replace(/"/g, '').trim().split('\\n');
    // lines.forEach(line => console.log(line));
    console.log('Saved..');

  fs.writeFile('P0.cs', arg, (err) => {
    if (err) throw err;
        console.log('Execute process..');
        exec('dnx run', function callback(error, stdout, stderr){
            event.sender.send('asynchronous-reply', stdout);
        });
    });
});

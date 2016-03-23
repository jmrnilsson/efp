'use strict';
const ipcRenderer = require('electron').ipcRenderer;
const fs = require('fs');
const ko = require('./curl/knockout-3.4.0.js');

ipcRenderer.on('asynchronous-reply', function(event, arg) {
  console.log(arg);
});

function callback(sender, arg) {
    textarea_value = arg;
}

function QueryModel() {
    var self = this;
    self.csscript = ko.observable(fs.readFileSync('./dotnet/Program.cs.001'));
    self.go = function () {
        ipcRenderer.send('my-msg', self.csscript());
    }
}
ko.applyBindings(new QueryModel(), document.getElementsByTagName('body')[0]);
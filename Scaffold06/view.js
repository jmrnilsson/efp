'use strict';

const ipc = require('electron').ipcRenderer;
const fs = require('fs');
const ko = require('./curl/knockout-3.4.0.js');
const Q = require('q');

// var csscript = ko.observable('');
var go = () => { ipc.send('go', csscript()); };

var editorOptions = { lineNumbers: true, mode: 'csharp' };
var textArea = document.getElementsByTagName('textarea')[0];
var editor = CodeMirror.fromTextArea(textArea, editorOptions);

Q.nfbind(fs.readFile)('./dotnet/Program.cs.003', 'utf8').then(e => {
    // csscript(e)
    editor.setValue(e);
    editor.refresh();
});

ipc.on('on-result', function(event, arg) {
  console.log(arg);
});

function QueryModel() {
    var self = this;
    self.go = go
    // self.csscript = csscript;
}

ko.applyBindings(new QueryModel(), document.getElementsByTagName('body')[0]);


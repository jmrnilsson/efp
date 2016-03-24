'use strict';

const ipc = require('electron').ipcRenderer;
const fs = require('fs');
const ko = require('./curl/knockout-3.4.0.js');
const Q = require('q');
const CodeMirror = require('codemirror');

function runScript() {
    ipc.send('go', editor.getValue());
}

var editorOptions = {
    lineNumbers: true,
    mode: 'clike'
};

var textArea = document.getElementsByTagName('textarea')[0];
var editor = CodeMirror.fromTextArea(textArea, editorOptions);

Q.nfbind(fs.readFile)('./dotnet/Program.cs.003', 'utf8').then(e => {
    editor.setValue(e);
    editor.refresh();
});

ipc.on('on-result', function(event, arg) {
  console.log(arg);
});

var el = document.getElementsByTagName('body')[0];
var model = {runScript: runScript};
ko.applyBindings(model, el);


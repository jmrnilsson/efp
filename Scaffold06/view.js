'use strict';

const ipc = require('electron').ipcRenderer;
const fs = require('fs');
const ko = require('./curl/knockout-3.4.0.js');
const Q = require('q');
const CodeMirror = require('codemirror');

let headers = ko.observableArray();
let rows = ko.observableArray();

function run() {
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

ipc.on('on-result', function(event, args) {
    console.log(args);
    let index = -1;
    let dbHeaders = {};
    let dbRows = [];
    for (var i = 0; i < args; i++) {
        for(var attr in args[i]) {
            if (args.hasOwnProperty(attr)) {
                if (!headers.hasOwnProperty(attr)) {
                    headers[attr] = index++;
                }
                var row = [];
                row[headers[attr]] = args[i][attr];
                dbRows.push(row);
            }
        }
    }
    rows.removeAll();
    headers.removeAll();
    dbRows.forEach(r => rows.push(r));
    for (var i = 0; i < dbHeaders.length; i++) {
        for(var attr in dbHeaders) {
            if (arg.hasOwnProperty(attr)) {
                if (attr === i) {
                    headers.push(dbHeaders[attr]);
                }
            }
        }
    }
});

var el = document.getElementsByTagName('body')[0];
var model = {run: run, headers: headers, rows: rows};
ko.applyBindings(model, el);


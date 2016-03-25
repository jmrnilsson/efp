'use strict';

const ipc = require('electron').ipcRenderer;
const fs = require('fs');
const ko = require('./curl/knockout-3.4.0.js');
const Q = require('q');
const CodeMirror = require('codemirror');
const smooths = require('./scroll.js');

const headers = ko.observableArray();
const rows = ko.observableArray();
const textArea = document.getElementsByTagName('textarea')[0];
const editorOptions = {
    lineNumbers: true,
    mode: 'clike',
};
const editor = CodeMirror.fromTextArea(textArea, editorOptions);

function run() {
    ipc.send('go', editor.getValue());
}


Q.nfbind(fs.readFile)('./dotnet/Program.cs.003', 'utf8').then(e => {
    editor.setValue(e);
    editor.refresh();
    window.scrollTo(0, 0);
});

ipc.on('on-result', (event, args) => {
    let index = 0;
    const dbHeaders = {};
    const dbRows = [];
    for (let i = 0; i < args.length; i++) {
        const row = [];
        for (let attr in args[i]) {
            if (Object.prototype.hasOwnProperty.call(args[i], attr)) {
                if (!Object.prototype.hasOwnProperty.call(dbHeaders, attr)) {
                    dbHeaders[attr] = index++;
                }
                row[dbHeaders[attr]] = args[i][attr];
            }
        }
        dbRows.push(row);
    }
    rows.removeAll();
    headers.removeAll();
    dbRows.forEach(r => rows.push(r));
    const len = Object.getOwnPropertyNames(dbHeaders).length;
    for (let i = 0; i < len; i++) {
        for (let attr in dbHeaders) {
            if (Object.prototype.hasOwnProperty.call(dbHeaders, attr)) {
                if (dbHeaders[attr] === i) {
                    headers.push(attr);
                }
            }
        }
    }
});

const el = document.getElementsByTagName('body')[0];
const model = {run, headers, rows, smoothScroll: smooths.smoothScroll};
ko.applyBindings(model, el);


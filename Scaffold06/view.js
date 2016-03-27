'use strict';

const ipc = require('electron').ipcRenderer;
const fs = require('fs');
const ko = require('./curl/knockout-3.4.0.js');
const Q = require('q');
const CodeMirror = require('codemirror');
const smooths = require('./scroll.js');

const headers = ko.observableArray();
const rows = ko.observableArray();
const editor = (function () {
    const el = document.getElementsByTagName('textarea')[0];
    return CodeMirror.fromTextArea(el, { lineNumbers: true });
}());


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
    const keys = {};
    const values = [];
    for (let i = 0; i < args.length; i++) {
        const row = [];
        const attrs = Object.getOwnPropertyNames(args[i]);
        for (let j = 0; j < attrs.length; j++) {
            if (!Object.prototype.hasOwnProperty.call(keys, attrs[j])) {
                keys[attrs[j]] = index++;
            }
            row[keys[attrs[j]]] = args[i][attrs[j]];
        }
        values.push(row);
    }
    rows.removeAll();
    headers.removeAll();
    values.forEach(r => rows.push(r));
    const attrs = Object.getOwnPropertyNames(keys);
    for (let i = 0; i < attrs.length; i++) {
        for (let j = 0; j < attrs.length; j++) {
            if (keys[attrs[j]] === i) {
                headers.push(attrs[j]);
            }
        }
    }
});

const el = document.getElementsByTagName('body')[0];
const model = {run, headers, rows, smoothScroll: smooths.smoothScroll};
ko.applyBindings(model, el);


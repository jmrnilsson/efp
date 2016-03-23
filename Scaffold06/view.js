'use strict';
const ipcRenderer = require('electron').ipcRenderer;

var textarea_value;

var button = document.getElementsByTagName('input')[0];
var textarea = document.getElementsByTagName('textarea')[0];
textarea.addEventListener('change', callback, false);

button.onclick = function(){
    let expression = textarea.innerHTML;
    ipcRenderer.send('my-msg', expression);
}

ipcRenderer.on('asynchronous-reply', function(event, arg) {
  console.log(arg);
});

function callback(sender, arg) {
    textarea_value = arg;
}
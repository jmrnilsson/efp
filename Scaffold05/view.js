'use strict';
const ipcRenderer = require('electron').ipcRenderer;

document.getElementsByTagName('input')[0].onclick = function(){
    let expression = document.getElementsByTagName('textarea')[0].innerHTML;
    ipcRenderer.send('my-msg', expression);
}

ipcRenderer.on('asynchronous-reply', function(event, arg) {
  console.log(arg);
});
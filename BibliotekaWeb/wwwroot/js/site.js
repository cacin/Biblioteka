﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function previewFiles() {

    var preview = document.querySelector('#preview');
    var files = document.querySelector('input[type=file]').files;
   
    function readAndPreview(file) {

        // Make sure `file.name` matches our extensions criteria
        if (/\.(jpe?g|png|gif)$/i.test(file.name)) {
            var reader = new FileReader();
            preview.innerText = ''
           
            reader.addEventListener("load", function () {
                var image = new Image();
                image.height = 100;
                image.title = file.name;
                image.src = this.result;
                preview.appendChild(image);

                let fotos = document.getElementById('foto');
                
                fotos.value = this.result.substr(this.result.indexOf(',') + 1);
               
            }, false);

            reader.readAsDataURL(file);
        }

    }

    if (files) {
        [].forEach.call(files, readAndPreview);
    }

};
$(document).ready(function () {
    var date = new Date();

    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    var today = year + "-" + month + "-" + day;
    $(".data").attr("value", today);
});



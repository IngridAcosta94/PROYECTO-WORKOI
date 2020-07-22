var img = null;
var imgris = null;
var imgred = null;
var can1 = document.getElementById("c1");
var file = document.getElementById("f1");

function cargar() {
    img = new SimpleImage(file);
    imgris = new SimpleImage(file);
    imgred = new SimpleImage(file);
    img.drawTo(can1);
}

function gris() {
    var hacegris;
    if (verificacarga()) {
        for (var pixel of imgris.values()) {
            hacegris = (pixel.getRed() + pixel.getBlue() + pixel.getGreen()) / 3;
            pixel.setRed(hacegris);
            pixel.setGreen(hacegris);
            pixel.setBlue(hacegris);
        }
        imgris.drawTo(can1);
    } else
        alert('No cargo');

}

function rojo() {
    if (verificacarga()) {
        var promrojo;
        for (var pixel of imgred.values()) {
            promrojo = (pixel.getRed() + pixel.getGreen() + pixel.getBlue()) / 3;
            if (promrojo < 128) {
                pixel.setRed(promrojo * 2);
                pixel.setGreen(0);
                pixel.setBlue(0);
            } else {
                pixel.setRed(255);
                pixel.setGreen((promrojo * 2) - 255);
                pixel.setBlue((promrojo * 2) - 255);
            }
        }
        imgred.drawTo(can1);
    } else {
        alert('No cargo');
    }
}

function reset() {
    img.drawTo(can1);
    imgris = new SimpleImage(file);
    imgred = new SimpleImage(file);
}

function verificacarga() {
    if (img == null || !img.complete())
        return false;
    else
        return true;
}
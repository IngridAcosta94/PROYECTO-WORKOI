var img = null;
var can1 = document.getElementById("c1");
var file = document.getElementById("f1");

function cargar() {
    img = new SimpleImage(file);
    img.drawTo(can1);
}

/*function reset() {
    img.drawTo(can1);
    imgris = new SimpleImage(file);
    imgred = new SimpleImage(file);
}*/

function verificacarga() {
    if (img == null || !img.complete())
        return false;
    else
        return true;
}
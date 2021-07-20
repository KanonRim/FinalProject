if (document.getElementById('hider')) {
    document.getElementById('hider').onclick = function () {
        document.getElementById('menu').style.display = 'none';
        document.getElementById('hiddenMenu').style.display = 'flex';
    }
    document.getElementById('hiddenMenu').onclick = function () {
        document.getElementById('menu').style.display = 'flex';
        document.getElementById('hiddenMenu').style.display = 'none';
    }
}




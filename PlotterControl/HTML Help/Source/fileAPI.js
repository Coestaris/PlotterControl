function CheckAvailable() {
    var fileAPISupport = false;
    if (window.File && window.FileReader && window.FileList && window.Blob) {
        fileAPISupport = true;
    }
    return fileAPISupport;
}

function FileApi()
{
    if (!CheckAvailable()) alert("NONE!");
    return;
    document.querySelector('input').addEventListener('change', onFile, false);
}

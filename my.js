

function editor_loaded() {


        showview();
    

var iframe = document.getElementById("editor_frame");
var iframeDocument = iframe.contentDocument || iframe.contentWindow.document;
	 
iframeDocument.designMode = "On";




// if(document.addEventListener)
// {
//    frames['editor_frame'].document.addEventListener('onkeyup', getHTML, false);
// } else if (document.attachEvent){
//  frames['editor_frame'].document.attachEvent('onkeyup', getHTML, false);
// }


}


function editor_createlink() {
	if (document.getSelection) {
		editor_FormatText('CreateLink', prompt('Link','http://'));
	} else {
		editor_FormatText('CreateLink');
	}

	getHTML();
}


function editor_FormatText(command, option) {
	editor_frame.focus();
	editor_frame.document.execCommand(command, false, option);
	getHTML();
}


function setcolor(command, option) {
	editor_frame.focus();
	editor_frame.document.execCommand(command, false, option);
	getHTML();
}


function editor_button_on(what) {
    what.className = 'editor_button_hover';
}
function editor_button_off(what) {
    what.className = 'editor_button';
}



function getHTML() {
	document.getElementById("edited_html").value=editor_frame.document.body.innerHTML;
}

function setHTML() {
	editor_frame.document.body.innerHTML = document.getElementById('edited_html').value;
}



function editor_get_range() {
	if (document.selection) {
		editor_frame.focus();
		editor_range = editor_frame.document.selection.createRange();
	} else if (document.getSelection) {
		editor_range = document.getElementById("editor_frame").contentWindow.getSelection().getRangeAt(0).cloneRange();
	} else {
		alert('Your browser is not supporting this feature');
		editor_range = false;
	}
}




function showhtml() {
    getHTML();
    document.getElementById('editor_frame').style.display = 'none';
    document.getElementById('edited_html').style.display = 'block';

    document.getElementById('btnHtml').style.display = 'none';
    document.getElementById('btnView').style.display = 'block';
}


function showview() {
    setHTML();
    document.getElementById('editor_frame').style.display = 'block';
    document.getElementById('edited_html').style.display = 'none';

    document.getElementById('btnHtml').style.display = 'block';
    document.getElementById('btnView').style.display = 'none';
}


function pasteImage(urlik) {
    
        editor_frame.focus();
        editor_frame.document.execCommand('insertimage', false, urlik);
        getHTML();

}




















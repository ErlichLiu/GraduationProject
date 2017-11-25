function setCookies(name, value) {
        var expdate = new Date();
        expdate.setTime(expdate.getTime() + 10 * 60 * 1000);
        console.log(expdate);
        document.cookie = name + "=" + value + "; expdate = " + expdate.toUTCString();
    }

function getCookies(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}
function delCookies(name){
	
	var exp = new Date();
	exp.setTime(exp.getTime() - 1);
	var cval=getCookie(name);
	if(cval!=null)
	document.cookie= name + "="+cval+";expires="+exp.toGMTString();
}
/*
    //初始化物件
    initObj = {
        btnSearchID: "控制項 id"
    }
*/


function checkInput() {
    var txt = document.getElementById(initObj.btnSearchID);

    if (txt) {
        if (txt.value.length == 0) {
            alert('尚未輸入值');
            return false;
        }
    }
    return true;
}
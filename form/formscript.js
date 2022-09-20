function isUser(username){
    var len=username.length;
    if(len>=3&&len<=25){
        return true;
    }
    return false;
}

function isEmail(email){
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if(!regex.test(email)) {
        return false;
    }
    return true;
}

function isPass(password){
    var reg=/[!@#$%^&*]/;
    if(password.length<=8){
        return false;
    }
    if (!/[A-Z]/.test(password)) {
        return false;
    }
    if (!/[a-z]/.test(password)) {
        return false;
    }
    if (!/[0-9]/.test(password)) {
        return false;
    }
    if(!/[!@#$%^&*]/.test(password)){
        return false;
    }
    return true;
}

$("#submit").click(function(){
    var nameError="";
    var nameMissing="";
    var emailMissing="";
    var emailError="";
    var passError="";
    var cnfError="";
    if($("#username").val()==""){
        nameMissing+="<br>Username field is empty";
    }
    if($("#email").val()==""){
        emailMissing+="<br>Email field is empty";
    }
    if(nameMissing!=""){
        nameError+=nameMissing;
    }
    if(emailMissing!=""){
        emailError+=emailMissing;
    }
    if(isEmail($("#email").val())==false){
        emailError+="<br>Email is not valid";
    }
    if(isUser($("#username").val())==false){
        nameError+="<br>Username must be between 3 and 25 characters";
    }
    if(isPass($("#password").val())==false){
        passError+="<br>Password must has at least 8 characters that include";
        passError+="<br>at least 1 lowercase character, 1 uppercase";
        passError+="<br>character, 1 number, and 1 special character in";
        passError+="<br>(!@#$%^&*)";
    }
    if($("#cnfmPsw").val()==""){
        cnfError+="<br>Please enter your password again";
    }
    if($("#password").val()!=$("#cnfmPsw").val()){
        alert("Passwords are not matching");
    }
    if(nameError!=""||passError!=""||emailError!=""||cnfError!=""){
        $("#nameError").html(nameError);
        $("#emailError").html(emailError);
        $("#passError").html(passError);
        $("#cnfError").html(cnfError);
    }
    else{
        $("#nameError").hide();
        $("#emailError").hide();
        $("#passError").hide();
        $("#cnfError").hide();
        alert("You are signed up!");
    }
});

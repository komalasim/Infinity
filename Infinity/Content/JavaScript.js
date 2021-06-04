function SlideOpen() {
  document.getElementById("mySidenav").style.width = "250px";
};

function SlideClose() {
  document.getElementById("mySidenav").style.width = "0";
};

function ValidateLogin() {
    let form = document.getElementById("Login");
    EmailFormat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    PasswordFormat = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
    
    if(form.Email.value == "") {
      alert("Error: Please enter your email ID.");
      form.Email.focus();
      return false;
    }

    if(!EmailFormat.test(form.Email.value)) {
      alert("Error: Please enter a valid email ID.");
      form.Email.focus();
      return false;
    }

    if(form.Password.value == "") {
      alert("Error: Please enter your password.");
      form.Password.focus();
      return false;
    }

    if(!PasswordFormat.test(form.Password.value)) {
      alert("Error: Password should be between 8 to 15 characters which contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character.");
      form.Password.focus();
      return false;
    }

    alert("LOGIN SUCCESFUL!");
    return true;
  }

  function ValidateSignup() {
    EmailFormat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    PasswordFormat = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;

    let form = document.getElementById("Signup");
    if(form.FName.value == "") {
      alert("Error: Please enter your first name.");
      form.FName.focus();
      return false;
    }

    if(form.LName.value == "") {
      alert("Error: Please enter your last name.");
      form.LName.focus();
      return false;
    }

    if(form.Email.value == "") {
      alert("Error: Please enter your email ID.");
      form.Email.focus();
      return false;
    }

    if(!EmailFormat.test(form.Email.value)) {
      alert("Error: Please enter a valid email ID.");
      form.Email.focus();
      return false;
    }

    if(form.Password.value == "") {
      alert("Error: Please enter your password.");
      form.Password.focus();
      return false;
    }

    if(!PasswordFormat.test(form.Password.value)) {
      alert("Error: Password should be between 8 to 15 characters which contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character.");
      form.Password.focus();
      return false;
    }

    if(form.CPassword.value == "") {
      alert("Error: Please enter your confirmation password.");
      form.CPassword.focus();
      return false;
    }

    if (form.Password.value != form.CPassword.value)
    {
      alert("Error: Please check that you've entered and confirmed your password.");
      form.Password.focus();
      return false;
    }

    if (form.gender.value =="")
    {
      alert("Error: Please select a gender.");
      form.gender.focus();
      return false;
    }

    if (form.DOB.value =="")
    {
      alert("Error: Please add your date of birth.");
      form.DOB.focus();
      return false;
    }

    alert("SIGNUP REGISTRATION SUCCESFUL!");
    return true;
  }

function ShowAlert()
{
  document.getElementById("AddCart").style.display = "block";
  setTimeout(function(){ document.getElementById("AddCart").style.display = "none"; }, 5000);
}


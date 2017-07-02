var isMessageValid;
var isSubjectValid;
var isOptionSelected;

var form = document.forms['fmMain'];

// Issue reading values that result in 'undefined' not 'null'

function ValidateForm() {
    isMessageValid = false;
    isSubjectValid = false;
    isOptionSelected = false;

    message = $('#txtMessage');
    messageSubject = $('#txtSubject');
    messageOptions = $('#selOptions');

    messageOptions = $('select#selOptions');

    // Issue reading values
    var messageValue = message.val();
    var messageOptionsValue = $('#selOptions option:selected').val();

    //alert('message:- ' + messageValue);
    //alert('Selected Options:- ' + messageOptionsValue);

    // Invalid message
    regex = /<script.*?>([\s\S]*?)<\/script>/;
    /*
    if (!regex.test(messageValue) && !(messageValue === undefined)) {
        if (messageValue.length > 3) {
            isMessageValid = true;
            alert('message Valid');
            message.css("border-size", "1px");
            message.css("border-color", "Default");
        }
        else {
            alert('Please enter a longer message');
            message.css("border-size", "1px");
            message.css("border-color", "red");
        }
    }
    else {
        if (regex.test(messageValue)) {
            // Message contains scripts/HTML
            alert('Message contains: ' + regex);
        }
        else {
            alert('Message is ' + undefined);
            message.css("border-size", "1px");
            message.css("border-color", "red");
        }
    }

    /**/

    //isMessageValid = true;

    /*
    if (messageOptionsValue === null || messageOptionsValue === undefined) {
        alert('Please select something');
        isOptionSelected = false;
        messageOptions.css("border-size", "1px");
        messageOptions.css("border-color", "Red");
    }
    else {
        isOptionSelected = true;
    }
    /**/

    isMessageValid = true;
    isSubjectValid = true;
    isOptionSelected = true;

    SubmitForm();
}

function SubmitForm() {
    if (isMessageValid && isSubjectValid && isOptionSelected) {
        /*
        alert('Final message: ' + $('txtMessage').value);
        alert('Final message: ' + $('txtMessage').value);
        alert('Final Options: ' + $('selOptions').selectedValue);
        /**/
        form.submit();
        alert('Message sent for submission');
        form.reset();
    }
    else {
        alert('There was an issue with submitting your message');
        //form.reset();
    }
}

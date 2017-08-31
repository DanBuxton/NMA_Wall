var isSubjectValid;
var isCommentValid;
var isImageValid;
var isOptionSelected;

var form = document.forms['fmMain'];

// Issue reading values that result in 'undefined' not 'null'

function ValidateForm() {
    isCommentValid = false;
    isSubjectValid = false;
    isOptionSelected = false;
    isImageValid = false;

    subject = $("#txtSubject");
    subjectText = subject.text();
    comment = $("#txtComment");
    commentText = comment.text();
    image = $("#imgComment");
    imageVal = image.val();

    // Harmful text
    regex = /<script.*?>([\s\S]*?)<\/script>/;

    // Subject Validation
    if (subjectText.length >= 5) {
        if (!subjectText.Contains(regex)) {
            isSubjectValid = true;
        }
    }

    // Comment Validation
    if (commentText.length >= 5) {
        if (!commentText.Contains(regex)) {
            isCommentValid = true;
        }
    }

    // Selection Validation
    // Done in HTML markup

    //Image Validation
    if (imageVal !== "") {
        switch (imageVal.substring(imageVal.lastIndexOf('.').toLowerCase())) {
            case 'gif':
            case 'png':
            case 'jpg':
            case '':
                isImageValid = true;
                break;
            default:
                alert("Please select an image");
                break;
        }
    }

    return SubmitForm();
}

function SubmitForm() {
    result = false;

    if (isSubjectValid && isCommentValid && isImageValid && isOptionSelected) {
        /*
        alert('Final message: ' + $('txtMessage').val());
        alert('Final message: ' + $('txtMessage').val());
        alert('Final Options: ' + $('selOptions').selectedValue);
        /**/
        alert('Message sent for submission');

        result = true;
    }
    else {
        alert('There was an issue with submitting your message');
    }

    return result;
}

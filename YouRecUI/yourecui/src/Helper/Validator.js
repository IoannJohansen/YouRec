export const EmailValidationOptions = {
    required: { value: true, message: "Email is required" },
    pattern: {
        value: /\S+@\S+\.\S+/,
        message: "Entered value does not match email format"
    }
}

export const PasswordValidationOptions = {
    required: { value: true, message: "Password required" },
    minLength: { value: 8, message: "Minimal password length: 8" },
    maxLength: { value: 40, message: "Maximal password length: 40" },
    pattern: {
        value: /^(?=.*\d)(?=.*[A-Za-z])(?=.*[A-Za-z]).{8,}$/,
        message: "Password must contain at least 8 chars and contains at least 1 number"
    }
}

export const FirstNameValidationOptions = {
    required: { value: true, message: "First name field is required" },
    minLength: { value: 2, message: "Minimal First name length: 2" },
    maxLength: { value: 25, message: "Maximal First name length: 25" }
}

export const LastNameValidationOptions = {
    required: { value: true, message: "Last name field is required" },
    minLength: { value: 2, message: "Minimal Last name name length: 2" },
    maxLength: { value: 25, message: "Maximal Last name length: 25" }
}
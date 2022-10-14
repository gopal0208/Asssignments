import React, { useState } from "react";
import "./App.css";
import SignedUp from "./SignedUp";

function App() {

  const initialValues = {
    username: "",
    email: "",
    password: "",
    confirmPassword: ""
  };

  const [formValues, setFormValues] = React.useState(initialValues);

  const [formErrors, setFormErrors] = useState({});

  const [isSubmit, setIsSubmit] = useState(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormValues({ ...formValues, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setFormErrors(validate(formValues));
    setIsSubmit(true);
  };

  const validate = (values) => {

    const errors = {};
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
    const specialCharacterPasswordRegex = /[!@#$%^&*]/;
    const uppercasePasswordRegex = /[A-Z]/;
    const lowerCasePasswordRegex = /[a-z]/;
    const numPasswordRegex = /[0-9]/;

    if (values.username.length === 0) {
      errors.username = "Username cannot be blank";
    }

    if (values.username.length < 3 || values.username.length > 25) {
      errors.username = "Username must be between 3 and 25 characters";
    }

    if (!values.email) {
      errors.email = "Email is mandatory";
    }

    else if (!emailRegex.test(values.email)) {
      errors.email = "Email is not valid";
    }

    if (!specialCharacterPasswordRegex.test(values.password) ||
      !uppercasePasswordRegex.test(values.password) ||
      !lowerCasePasswordRegex.test(values.password) ||
      !numPasswordRegex.test(values.password)) {
        errors.password = "Password must has at least 8 characters that include at least 1 lowercase character, 1 uppercase character, 1 number, and 1 special character in(!@#$%^&*)";
    }

    if (values.confirmPassword !== values.password) {
      errors.confirmPassword = "Please enter your password again";
    }

    return errors;

  };

  return (
    <div className="container">
      {Object.keys(formErrors).length === 0 && isSubmit ? (
        <SignedUp />
      ) : (
        <div></div>
      )}

      <form onSubmit={handleSubmit}>

        <h1>Sign Up</h1>
        <div>

          <div className="field">
            <label>Username:</label>
            <input
              type="text"
              name="username"
              value={formValues.username}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.username}</p>

          <div className="field ele">
            <label>Email</label>
            <input
              type="text"
              name="email"
              placeholder="Email"
              value={formValues.email}
              onChange={handleChange}
            />
          </div>

          <p>{formErrors.email}</p>
          <div className="field">
            <label>Password:</label>
            <input
              type="password"
              name="password"
              value={formValues.password}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.password}</p>

          <div className="field">
            <label>Confirm Password:</label>
            <input
              type="password"
              name="confirmPassword"
              placeholder="Re-enter your Password"
              value={formValues.confirmPassword}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.confirmPassword}</p>

          <button>Sign Up</button>
        </div>
      </form>
    </div>
  );
}

export default App;

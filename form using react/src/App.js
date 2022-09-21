import { useState, useEffect } from "react";
import "./App.css";

function App() {
  const initialValues = { username: "", email: "", password: "", cnfpass: ""};
  const [formValues, setFormValues] = useState(initialValues);
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

  useEffect(() => {
    console.log(formErrors);
    if (Object.keys(formErrors).length === 0 && isSubmit) {
      console.log(formValues);
    }
  }, [formErrors]);
  const validate = (values) => {
    const errors = {};
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/i;
    if (values.username.length<3||values.username.length>25) {
      errors.username = "Username must be between 3 and 25 characters";
    }
    if (!values.email) {
      errors.email = "Email is mandatory";
    } else if (!regex.test(values.email)) {
      errors.email = "Email is not valid";
    }
    if(!/[!@#$%^&*]/.test(values.password)||!/[A-Z]/.test(values.password)||!/[a-z]/.test(values.password)||!/[0-9]/.test(values.password)){
      errors.password ="Password must has at least 8 characters that include at least 1 lowercase character, 1 uppercase character, 1 number, and 1 special character in(!@#$%^&*)";
  }
    if(values.cnfpass!==values.password){
      errors.cnfpass="Please Enter your password again";
    }
    return errors;
  };

  return (
    <div className="container">
      {Object.keys(formErrors).length === 0 && isSubmit ? (
        alert("You are signed up!")
      ) : (
        <pre>{JSON.stringify(formValues, undefined, 2)}</pre>
      )}

      <form onSubmit={handleSubmit}>
        <h1>Sign Up</h1>
        <div className="ui divider"></div>
        <div className="ui form">
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
              name="cnfpass"
              placeholder="Re-enter your Password"
              value={formValues.cnfpass}
              onChange={handleChange}
            />
          </div>
          <p>{formErrors.cnfpass}</p>
          <button>Sign Up</button>
        </div>
      </form>
    </div>
  );
}

export default App;
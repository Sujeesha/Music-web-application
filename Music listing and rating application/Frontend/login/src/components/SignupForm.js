import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "../styles/SignupForm.css";

function SignupForm() {
  const [name, setName] = useState("");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [successMessage, setSuccessMessage] = useState(""); // New state for success message
  const navigate = useNavigate();

  const handleSignup = async (e) => {
    e.preventDefault();

    const userData = {
      name: name,
      username: username,
      email: email,
      password: password,
    };

    try {
      const response = await fetch(
        "https://localhost:7276/api/Authenticate/register",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(userData),
        }
      );

      if (response.ok) {
        // Clear form data
        setName("");
        setUsername("");
        setEmail("");
        setPassword("");

        // Display success message
        setSuccessMessage("User registered successfully.Redirecting to Login page....");

        // Redirect back to the login page after a short delay
        setTimeout(() => {
          navigate("/login");
        }, 2000); // Redirect after 3 seconds
      } else {
        // Handle error response
        console.error("Error registering user");
      }
    } catch (error) {
      // Handle network or other errors
      console.error("Error registering user:", error);
    }
  };

  return (
    <div className="signup-container">
      <h2>New User</h2>
      {/* Display the success message */}
      {successMessage && <p className="success-message">{successMessage}</p>}
      <form onSubmit={handleSignup}>
        <div className="form-group">
          <label htmlFor="name">Name</label>
          <input
            type="text"
            id="name"
            name="name"
            className="form-control"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="username">Username</label>
          <input
            type="text"
            id="username"
            name="username"
            className="form-control"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="email">Email</label>
          <input
            type="email"
            id="email"
            name="email"
            className="form-control"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>
        <div className="form-group">
          <label htmlFor="password">Password</label>
          <input
            type="password"
            id="password"
            name="password"
            className="form-control"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Sign Up
        </button>
      </form>
    </div>
  );
}

export default SignupForm;

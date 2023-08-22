import React, { useState } from "react";
import { Link } from "react-router-dom";
import "../styles/Login.css"; // Import your custom CSS file

function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async (e) => {
    e.preventDefault();

    // Prepare the login data to be sent to the microservice
    const loginData = {
      username: username,
      password: password,
    };

    try {
      const response = await fetch("https://localhost:7276/api/Authenticate/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(loginData),
      });

      if (response.ok) {
        // Handle successful login (e.g., show a success message, redirect to dashboard, etc.)
        console.log("User logged in successfully");
      } else {
        // Handle login error (e.g., show an error message)
        console.error("Error logging in");
      }
    } catch (error) {
      // Handle network or other errors
      console.error("Error logging in:", error);
    }
  };

  return (
    <div className="login-container">
      <h2>Login</h2>
      <form onSubmit={handleLogin}>
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
          Login
        </button>
      </form>
      <div className="login-links">
        <Link to="/signup">Create New Account</Link>
      </div>
    </div>
  );
}

export default Login;

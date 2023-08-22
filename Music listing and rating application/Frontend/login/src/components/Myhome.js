import React from "react";
import "../App.css";

function Myhome() {
  return (
    <div className="home-container">
      <div className="home-content">
        <h2 className="animate-slide-in-left">WELCOME TO SOUL OF MUSIC</h2>
        <h1 className="blue-heading">MUSIC HUB</h1>

        <h2 className="animate-slide-in-right">Listen to loads of songs for free!</h2>
        <div className="home-buttons">
          <a href="/login" className="btn btn-primary">
            Login
          </a>
        </div>
      </div>
    </div>
  );
}

export default Myhome;

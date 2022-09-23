import React from "react";
import "./mystyle.css";

function Rep({ Img, email, firstName, lastName }) {
  return (
    <div className="ele">
      <div>
        <div className="profile">
          <img src={Img} alt="" />
        </div>

        <div className="title">
          {email}
          <span>
            <br></br>
            {firstName} {lastName}
          </span>
          <p></p>
        </div>
      </div>
    </div>
  );
}

export default Rep;

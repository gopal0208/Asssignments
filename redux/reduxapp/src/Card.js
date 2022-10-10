import React from "react";
import "./mystyle.css";

function Card({ Img, email, firstName, lastName }) {
  return (
    <div class="card ele">
      <img class="card-img-top img" src={Img} alt="Card img cap" />
      <div class="card-body">
        <h5 class="card-title">
          {email}
          <br></br>
          {firstName} {lastName}
        </h5>
      </div>
    </div>
  );
}

export default Card;

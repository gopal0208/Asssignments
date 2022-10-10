import React, { useEffect } from "react";
import { GethUsers } from "./redux/actions";
import { connect } from "react-redux";
import Card from "./Card";

function View({ GethUsers, user: { users, loading } }) {
  useEffect(() => {
    GethUsers();
  }, [GethUsers]);

  let cards;
  if (users === null || loading) {
    cards = <div>Loading</div>;
  } else {
    console.log(users);
    cards = users.map((card) => (
      <Card
        key={card.id}
        Img={card.avatar}
        email={card.email}
        firstName={card.first_name}
        lastName={card.last_name}
      />
    ));
  }
  return <div>{cards}</div>;
}

const mapStateToProps = (state) => ({
  user: state.user
});

export default connect(mapStateToProps, { GethUsers })(View);

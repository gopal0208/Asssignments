import React, { useEffect } from "react";
import { GethUsers } from "./redux/actions";
import { connect } from "react-redux";
import Rep from "./Rep";

function View({ GethUsers, user: { users, loading } }) {
  useEffect(() => {
    GethUsers();
  }, [GethUsers]);

  let reps;
  if (users === null || loading) {
    reps = <div>Loading</div>;
  } else {
    console.log(users);
    reps = users.map((rep) => (
      <Rep
        key={rep.id}
        Img={rep.avatar}
        email={rep.email}
        firstName={rep.first_name}
        lastName={rep.last_name}
      />
    ));
  }
  return <div>{reps}</div>;
}

const mapStateToProps = (state) => ({
  user: state.user
});

export default connect(mapStateToProps, { GethUsers })(View);

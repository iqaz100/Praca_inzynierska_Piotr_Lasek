import React from "react";
import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
import Grid from "@material-ui/core/Grid";
import Tooltip from "@material-ui/core/Tooltip";
import Icon from "@material-ui/core/Icon";

var styles = {
  courseName: {
    fontWeight: "bold"
  }
};

var gradeColor;

class Course extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      name: props.name,
      grades: props.grades,
      icon: ""
    };
    this.setProperIcon();
  }

  setProperIcon() {
    switch (this.state.name) {
      case "Polski":
        this.setState({ icon: "schoolicon" });
        break;
      case "WF":
        this.setState({ icon: "DirectionsRun" });
        break;
      default:
        break;
    }
  }

  setColorOfGrade(grade) {
    switch (grade.gradeValue) {
      case 1:
        gradeColor = "Crimson";
        break;
      case 2:
        gradeColor = "Red";
        break;
      case 3:
        gradeColor = "RosyBrown";
        break;
      case 4:
        gradeColor = "blue";
        break;
      case 5:
        gradeColor = "Green";
        break;
      case 6:
        gradeColor = "Lime";
        break;
      default:
        gradeColor = "pink";
        break;
    }
    return gradeColor;
  }

  changeDate(gradeDateTime){
    return gradeDateTime.replace('T',' ')
  }

  render() {
    return (
      <TableRow key={this.state.name}>
        <TableCell component="th" scope="row">
          <p style={styles.courseName}>
            <Icon style={styles.icon}>{this.state.icon}</Icon>
            {this.state.name}
          </p>
        </TableCell>
        <TableCell align="right">
          <Grid container>
            {this.state.grades.map(grade => (
              <Tooltip
                title={
                  <React.Fragment>
                    <p>
                      <b>Waga: {grade.gradeScale}</b>
                    </p>
                    <p>
                      <b>Data wystawienia: {this.changeDate(grade.gradeDatetime)}</b>
                    </p>
                  </React.Fragment>
                }
              >
                <grid
                  item
                  xs={1}
                  className="tablelabel"
                  style={{ backgroundColor: this.setColorOfGrade(grade) }}
                >
                  {grade.gradeValue}
                </grid>
              </Tooltip>
            ))}
          </Grid>
        </TableCell>
      </TableRow>
    );
  }
}

export default Course;

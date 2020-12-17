import React from "react";
import TableCell from "@material-ui/core/TableCell";
import TableRow from "@material-ui/core/TableRow";
import Grid from "@material-ui/core/Grid";
import Tooltip from "@material-ui/core/Tooltip";
import DirectionsRunIcon from "@material-ui/icons/DirectionsRun";
import AddGrade from "./AddGrade";
import Modal from "@material-ui/core/Modal";
import Backdrop from "@material-ui/core/Backdrop";
import Fade from "@material-ui/core/Fade";
import Button from "@material-ui/core/Button";
import ConnectDB from "../ConnectDB";

var styles = {
  courseName: {
    fontWeight: "bold"
  }
};

class StudentGrades extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      firstName: props.firstName,
      lastName: props.lastName,
      grades: props.grades,
      average:"",
      finalGrade: "",
      id: props.id,
      subjectId: props.subjectId
    };
    ConnectDB.getAverageGrade(this.state.id,this.state.subjectId).then(res => {
      this.setState({average:res})
    });
  }

  togglePopup() {
    this.setState({
      showPopup: !this.state.showPopup,
    });   
  }

  togglePopupDelete() {
    this.setState({
      showPopupDelete: !this.state.showPopupDelete
    });
  }

  deleteGrade(gradeToDelete) {
    console.log(this.state)
    ConnectDB.deleteGrade(gradeToDelete).then(res => {
      window.location.reload();
    });
    
  }

  render() {
    return (
      <TableRow key={this.state.name}>
        <TableCell component="th" scope="row" style={styles.courseName}>
          {this.state.firstName}
        </TableCell>
        <TableCell component="th" scope="row" style={styles.courseName}>
          {this.state.lastName}
        </TableCell>
        <TableCell align="right">
          <Grid container>
            {this.state.grades.map(grade => (
              <Tooltip key={grade}
                title={
                  <React.Fragment>
                    <p>
                      <b>Waga: {grade.gradeScale}</b>
                    </p>
                    <p>
                      <b>Data wystawienia: {grade.gradeDatetime}</b>
                    </p>
                  </React.Fragment>
                }
              >
                <Grid 
                  item
                  xs={1}
                  className="tablelabel"
                  onClick={this.togglePopupDelete.bind(this)}
                >
                  {grade.gradeValue}{" "}
                  
                    <Modal key={grade.gradeId}
                      className="modal"
                      open={this.state.showPopupDelete}
                      onClose={this.togglePopupDelete.bind(this)}
                      closeAfterTransition
                      BackdropComponent={Backdrop}
                      BackdropProps={{
                        timeout: 500
                      }}
                    >
                      <Fade in={this.state.showPopupDelete}>
                        <div className="paper">
                          <h2 id="transition-modal-title">
                            Czy na pewno chcesz usunac ocene?
                          </h2>
                          <p></p>
                          <Button onClick={() => this.deleteGrade(grade.gradeId)}>
                            TAK{" "}
                          </Button>
                        </div>
                      </Fade>
                    </Modal>
                  
                </Grid>
              </Tooltip>
            ))}
          </Grid>
        </TableCell>

        <TableCell
          component="th"
          scope="row"
          style={styles.courseName}
          align="center"
        >
          {this.state.average}
        </TableCell>
       
        <TableCell
          component="th"
          scope="row"
          style={styles.courseName}
          align="center"
        >
          {this.state.finalGrade}
        </TableCell>
        <TableCell
          component="th"
          scope="row"
          style={styles.courseName}
          align="center"
        >
          <button onClick={this.togglePopup.bind(this)}>DODAJ </button>
          {this.state.showPopup ? (
            <AddGrade
              showPopup={(this.state.showPopup = true)}
              firstName={this.state.firstName}
              lastName={this.state.lastName}
              idStudent={this.state.id}
              subjectId ={this.state.subjectId}
            ></AddGrade>
          ) : null
          //TUTAJ ZLE DZIALA STAN SHOWPOPUP, TRZEBA GO JAKOS ZEROWAC PO KLIKNIĘCIU
          }
        </TableCell>
        <TableCell
          component="th"
          scope="row"
          style={styles.courseName}
          align="center"
        >
          <button>EDYTUJ</button>
        </TableCell>
      </TableRow>
    );
  }
}

export default StudentGrades;

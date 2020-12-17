import React from "react";
import Tooltip from "@material-ui/core/Tooltip";
import {withStyles } from "@material-ui/core/styles";
import Modal from "@material-ui/core/Modal";
import Backdrop from "@material-ui/core/Backdrop";
import Fade from "@material-ui/core/Fade";
import TextareaAutosize from "@material-ui/core/TextareaAutosize";
import "../index.css";
import ConnectDB from "../ConnectDB";

const HtmlTooltip = withStyles(theme => ({
  tooltip: {
    backgroundColor: "#f5f5f9",
    color: "rgba(0, 0, 0, 0.87)",
    maxWidth: 220,
    fontSize: theme.typography.pxToRem(12),
    border: "1px solid #dadde9"
  }
}))(Tooltip);

var styles = {
  courseName: {
    fontWeight: "bold"
  }
};

class Absence extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      name: "nb",
      absenceId: props.absenceId,
      excused: props.excused,
      date: props.date,
      icon: ""
    };
    this.setProperIcon();
  }

  togglePopup() {
    var accountType = JSON.parse(localStorage.getItem('user')).typeId
    if(accountType === 2)
    {
      this.setState({
        showPopup: !this.state.showPopup
      }); 
    }
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

  setYesorNo(excused) {
    let isExcused;
    switch (excused) {
      case "0":
        isExcused = "NIE";
        break;
      case "1":
        isExcused = "TAK";
        break;
      default:
        break;
    }
    return isExcused;
  }

  sendExcuse() {
    this.togglePopup.bind(this);
    ConnectDB.excuseAbsence(this.state.absenceId).then(res => {
    });
    this.state.excused = "1";
    this.forceUpdate();
    this.togglePopup();
  }

  render() {
    return (
      <p >
        <HtmlTooltip
          title={
            <React.Fragment>
              <p>
                <b>Data nieobecnosci: {this.state.date}</b>
              </p>
              <p>
                <b>
                  Czy usprawiedliwiona: {this.setYesorNo(this.state.excused)}{" "}
                </b>
              </p>
            </React.Fragment>
          }
        >
          <p
            item
            xs={1}
            className="absencelabel"
            onClick={this.togglePopup.bind(this)}
          >
            {this.state.name}{" "}
          </p>
        </HtmlTooltip>

        {this.state.showPopup ? (
          <Modal
            className="modal"
            open={this.state.showPopup}
            onClose={this.togglePopup.bind(this)}
            closeAfterTransition
            BackdropComponent={Backdrop}
            BackdropProps={{
              timeout: 500
            }}
          >
            <Fade in={this.state.showPopup}>
              <div className="paper">
                <h2 id="transition-modal-title">
                  Usprawiedliwienie nieobecności
                </h2>
                <TextareaAutosize
                  aria-label="empty textarea"
                  placeholder="Powód nieobecności"
                />
                <p></p>
                <button onClick={() => this.sendExcuse()}>WYŚLIJ </button>
              </div>
            </Fade>
          </Modal>
        ) : null}
      </p>
    );
  }
}

export default Absence;

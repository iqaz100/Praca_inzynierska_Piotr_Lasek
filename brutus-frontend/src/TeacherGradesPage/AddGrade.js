import React from 'react';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import Button from '@material-ui/core/Button';
import '../index.css'
import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/lab/Autocomplete';
import ConnectDB from "../ConnectDB";




class AddGrade extends React.Component
{

    constructor(props)
    {
        super(props)
        this.state = {
            showPopup: props.showPopup,
            grades:["1","2","3","4","5","6"],
            wages:["1","2","3","4","5"],
            firstName:props.firstName,
            lastName:props.lastName,
            idStudent:props.idStudent,
            newGrade:"",
            newWage:"",
            subjectId:props.subjectId
        }
    }

    addStudentGrade(grade,wage,id,subjectId){
        grade = JSON.parse(grade)
        wage = JSON.parse(wage)
        subjectId = JSON.parse(subjectId)
        //ConnectDB.addGrade(this.state.newWage,"normal",this.state.idStudent,this.state.newGrade,1,1).then(res => console.log(res))
        ConnectDB.addGrade(wage,"normal",id,grade,1,subjectId)
        .then(res => {
            //window.location.reload();
        })
        this.forceUpdate();
        this.togglePopup();
        
    }

    togglePopup(){
        this.setState({
          showPopup:!this.state.showPopup
        });
      }


    render(){
        return(
        <div>
        {this.state.showPopup ?
        <Modal
        className="modal"
         open = {true}
        onClose={this.togglePopup.bind(this)}
        closeAfterTransition
        BackdropComponent={Backdrop}
        BackdropProps={{
         timeout: 500,
        }}
        >
        <Fade in={true}>
        <div className="paper">
            <h2 id="transition-modal-title">Dodawanie oceny</h2>
            <h3>Imię i nazwisko: {this.state.firstName} {this.state.lastName}</h3>
                <Autocomplete
                options={this.state.grades}
            getOptionLabel={option => option}
            style={{ width: 300 }}
            className="paper"
            renderInput={params => (
                <TextField {...params} inputRef={(c) => {this.state.newGrade = c}} name="newGrade" id="CoursComboBox" label="Ocena" variant="outlined" margin="normal" value = {this.state.newGrade} fullWidth onChange={this.handleChange} />
            )}
            />

            <Autocomplete
            options={this.state.wages}
            getOptionLabel={option => option}
            className="paper"
            style={{ width: 300 }}
            renderInput={params => (
                <TextField {...params} inputRef={(c) => {this.state.newWage = c}} id="classComboBox" label="Waga" variant="outlined" margin="normal" fullWidth  onChange={this.state.newWage=this.value}/>
            )}
            />
            <p></p>
            <Button onClick={() => this.addStudentGrade(this.state.newGrade.value,this.state.newWage.value,this.state.idStudent, this.state.subjectId) }>WYŚLIJ </Button>
        </div>
        </Fade>
        </Modal> : null 
        }            
        </div>
        )
    } 

}

export default AddGrade;
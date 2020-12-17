import React from 'react';
import 'typeface-roboto';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import ConnectDB from "../ConnectDB";
import '../index.css'
import Absence from './Absence'
import Grid from "@material-ui/core/Grid";

class SimpleTable extends React.Component
{
  constructor(props){
    super(props);
    this.state = {
      showPopup: false,
      courses: [
        {
          name:"Polski",
          absences:["nb","nb"]
        },
        {
          name:"WF",
          absences:["nb"]
        }
      ],
      courses2:[]
    };
    var loggedUserID = JSON.parse(window.localStorage.getItem('user')).id;
    ConnectDB.getAllStudentAbsences(loggedUserID).then(resp =>{
      this.setState({courses2: resp});
    })
    
  }

  togglePopup(){
    this.setState({
      showPopup:!this.state.showPopup
    });
  }

  changeDate(gradeDateTime){
    return gradeDateTime.replace('T',' ')
  }


  render(){ 

    return (
      <Paper className="classes.root">
        <Table className="table" aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell align="center">Nieobecności</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            <TableCell align="center">
              <Grid container>
            {this.state.courses2.map(row => ( 
              <Absence absenceId={row.absenceId} excused={row.excused} date={this.changeDate(row.lessonDatetime)}></Absence>
            ))}
            </Grid>
            </TableCell>
          </TableBody>
        </Table>      
      </Paper>
      
      
    );
  }
}

export default SimpleTable;
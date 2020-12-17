import React from 'react';
import Grid from '@material-ui/core/Grid';
import 'typeface-roboto';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Course from './Course'
import ConnectDB from "../ConnectDB";
import '../index.css'

class SimpleTable extends React.Component
{
  constructor(props){
    super(props);
    this.state = {
      courses: [
        {
          name:"Język Polski",
          grades:[[1,5,"12/12/2018"],[2,4,"12/12/2018"],[3,1,"13/12/2018"],[4,1,"15/12/2018"],[5,5,"15/12/2018"]]
        },
        {
          name:"Wychowanie Fizyczne",
          grades:[[5,5,"12/12/2018"],[4,4,"12/12/2018"],[3,1,"13/12/2018"],[2,1,"15/12/2018"],[6,5,"15/12/2018"]]
        }
      ],
      courses2:[]
      };
      var loggedUserID = JSON.parse(window.localStorage.getItem('user')).id;
      ConnectDB.getStudentGrades(loggedUserID).then(res =>{
        this.setState({courses2: res});
      })
  }

  render(){ 
    return (
      <Paper className="classes.root">
        <Table className="table" aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Przedmiot</TableCell>
              <TableCell align="left">Oceny</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {this.state.courses2.map(row => ( 
              <Course grades={row.grades} name={row.key}></Course>
            ))}
          </TableBody>
        </Table>
      </Paper> 
    );
  }
}

export default SimpleTable;
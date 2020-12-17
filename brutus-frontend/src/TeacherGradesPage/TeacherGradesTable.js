import React from 'react';
import 'typeface-roboto';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Tooltip from '@material-ui/core/Tooltip';
import StudentGrades from './StudentGrades'
import '../index.css'
import ConnectDB from "../ConnectDB";

class SimpleTable extends React.Component
{
  constructor(props){
    super(props);
    this.state = {
      courses: [
        {
          firstName:"Pjoter",
          lastName:"Kowalski",
          grades:[1,2,3,4,5],
          average:3,
          finalGrade:3,
          idStudent:1
        },
        {
          firstName:"Andrij",
          lastName:"Golota",
          grades:[2,2,2,6,1],
          average:2,
          finalGrade:3,
          idStudent:2
        }
      ],
      students: [],
      subjectID : props.subjectID,
      classID : props.classID
           
      };
      ConnectDB.getClassGrades(this.state.classID,this.state.subjectID).then(res => {
        this.setState({students: res})
        //this.setState({studentId: res.studentId})
        console.log("ID" + this.state.students)
        console.log("Wyswietlanie klas" + res);
      });
    
  }


  render(){   
  
    return (
      <Paper className="classes.root">
        <Table className="table" aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell>Imie</TableCell>
              <TableCell>Nazwisko</TableCell>
              <TableCell width="300px">Oceny</TableCell>
              <TableCell width="105px">Średnia</TableCell>
              <TableCell width="105px">Ocena końcowa</TableCell>
              <TableCell width="30px"></TableCell>
              <TableCell width="30px"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {this.state.students.map(row => ( 
              <StudentGrades grades={row.grades} firstName={row.firstName} lastName={row.lastName} id={row.studentId}></StudentGrades>
            ))}
          </TableBody>
        </Table>
      </Paper> 
    );
  }
}

export default SimpleTable;
import React, {useState, useEffect} from 'react';
import TextField from '@material-ui/core/TextField';
import Autocomplete from '@material-ui/lab/Autocomplete';
import ConnectDB from '../ConnectDB';
import SimpleTable from './TeacherGradesTable'
import { render } from 'react-dom';
import Grid from '@material-ui/core/Grid';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import StudentGrades from './StudentGrades'
import { DesktopWindows } from '@material-ui/icons';
import Button from '@material-ui/core/Button';

//Uzyj npm install @material-ui/lab aby zainstalowac "Autocomplete"



export default function ComboBox() {


  const [classes, setClasses] = useState();
  const [courses, setCourses] = useState();
  const [isLoading, setLoading] = useState(true);
  const [chosenClass,setChosenClass]  = useState(1);
  const [chosenSubject,setChosenSubject] = useState(1);
  const [students,setStudents] = useState([]);

  function loadStudents(classID,subjectID){
      setStudents([])
    ConnectDB.getClassGrades(classID,subjectID).then(res => {
      setStudents(res)
      console.log(classID)
      console.log(subjectID)
      console.log(students)
      //this.setState({studentId: res.studentId})
    });
  }
  
  //loadStudents(1,1)
  useEffect(() => {

    if(isLoading)
    {
    ConnectDB.getAllClasses()
    .then((data) => {
      setClasses(data);
    });

    ConnectDB.getAllCourses()
    .then((data2) => {
      setCourses(data2);
    });
    setLoading(false);
    }


  });


  return  (
    <Grid container direction="column"justify="center" alignItems="center">
    <Autocomplete
      options={courses}
      getOptionLabel={option => option.subjectName}
      style={{ width: 300 }}
      onChange ={(event,newSubject) => setChosenSubject(newSubject.subjectId)}
      renderInput={params => (
        <TextField {...params} id="CoursComboBox" label="Przedmiot" variant="outlined" margin="normal" fullWidth />
      )}
    />

      
    <Autocomplete
      options={classes} 
      getOptionLabel={option => option.classTitle}
      style={{ width: 300 }}
      onChange ={(event,newClass) => setChosenClass(newClass.classId)}
      renderInput={params => (
        <TextField {...params} id="classComboBox" label="Klasa" variant="outlined" margin="normal" fullWidth />
      )}
    />

    <Button onClick ={() => loadStudents(chosenClass,chosenSubject)} variant="contained" color="primary" style={{width: '15%',marginTop:30,marginBottom:30}} >Wyszukaj</Button>
    <Grid item xs={12}>
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
            {students.map(row => ( 
              <StudentGrades grades={row.grades} firstName={row.firstName} lastName={row.lastName} id={row.studentId} subjectId={chosenSubject}></StudentGrades>
            ))}
          </TableBody>
        </Table>
      </Paper> 
    </Grid>
    </Grid>


    
  )
  
}
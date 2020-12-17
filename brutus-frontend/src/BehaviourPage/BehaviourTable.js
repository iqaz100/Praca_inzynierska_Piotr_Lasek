import React from 'react';

import 'typeface-roboto';
import {withStyles} from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Tooltip from '@material-ui/core/Tooltip';
import ConnectDB from "../ConnectDB";
import '../index.css'

var styles = {
    courseName: {
        fontWeight: "bold"
    },
}

var gradeColor;

class SimpleTable extends React.Component
{
  constructor(props){
    super(props);
    this.state = {
      behaviour: [5,4,2,1,5,2,4],
      behavior:[]
      };

    ConnectDB.getStudentBehavior(1).then(res =>{
      this.setState({behavior: res});
    })
    
  }



  setColorOfGrade(beh){
    switch(beh){
      case 1:
        gradeColor = "Crimson"
        break;
      case 2:
        gradeColor = "Red"
        break;
      case 3:
        gradeColor = "RosyBrown"
        break;
      case 4:
        gradeColor = "blue"
        break;
      case 5:
        gradeColor = "Green"
        break;
      case 6:
        gradeColor = "Lime"
        break;
      default:
        gradeColor = "pink"
        break;
    }
  return gradeColor;
  }

  render(){ 
    return (
      <Paper className="classes.root">
        <Table className="table" aria-label="simple table">
          <TableHead>
            <TableRow>
                <TableCell></TableCell>
              <TableCell align="center"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody size="small">
              <TableCell style={styles.courseName }>Zachowanie</TableCell>
                  {this.state.behavior.map(beh=>(
                    <TableRow>
                    <Tooltip
                    title={
                      <React.Fragment>
                        <p><b>Typ: {beh.behaviorType}</b></p>
                      </React.Fragment>
                    }
                    >
                    <TableCell>{beh.behaviorDescription}</TableCell>
                  </Tooltip>
                  </TableRow>
                    ))}

          </TableBody>
        </Table>
      </Paper> 
    );
  }
}

export default SimpleTable;
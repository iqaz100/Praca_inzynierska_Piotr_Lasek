import React from 'react';
import Grid from '@material-ui/core/Grid';
import TeacherGradesMenu from './TeacherGradesMenu'


export default class HomePage extends React.Component{

  
    render() {
            return (
              <Grid container direction="column"justify="center" alignItems="center">
              <Grid item xs={12} justify="center" alignItems="center">
                <TeacherGradesMenu ></TeacherGradesMenu>
              </Grid>
            </Grid>
            );
    }
}
import React from 'react';
import Grid from '@material-ui/core/Grid';
import Logo from '../LoginPage/Logo'
import InputBox from '../LessonsPage/InputBox'
import '../index.css'
export default class HomePage extends React.Component{
    render() {
        {
            return (
              <Grid container direction="column"justify="center" alignItems="center">
              <Grid item xs={12}>
                <Logo></Logo>
              </Grid>
              <Grid item xs={12}>
                <InputBox></InputBox>
              </Grid>
            </Grid>
            );
          }
    }
}
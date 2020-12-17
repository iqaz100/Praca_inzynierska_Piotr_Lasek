import React from 'react';
import Grid from '@material-ui/core/Grid';
import InputBox from '../ProfilePage/InputBox'

var styles = {
  changePasswordText:{
    fontSize:20,
    marginTop: 0,
    marginBottom: -155,
    paddingTop: 150,
    marginLeft: -200,
    fontFamily: "Helvetica",
    fontWeight: "Bold"
  }
}

export default class HomePage extends React.Component{
    render() {
        {
            return (
              <Grid container direction="column"justify="center" alignItems="center">
              <Grid item xs={12}> <p style={styles.changePasswordText}>Zmień hasło</p></Grid>
              <Grid item xs={12}>
              <InputBox></InputBox>
              </Grid>
            </Grid>
            );
          }
    }
}
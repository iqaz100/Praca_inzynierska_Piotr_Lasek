import React from 'react';
import Grid from '@material-ui/core/Grid';
import Logo from './Logo'
import InputBox from './InputBox'

var styles = {
  loginToBrutus: {
    fontSize: 20,
    marginTop: 0,
    marginBottom: -155,
    paddingTop: 150,
    marginLeft: -200,
    fontFamily: "Helvetica",
    fontWeight: "Bold"
  }
}

export default class LoginPage extends React.Component{
    render() {
        {
            return (
              <Grid container direction="column"justify="center" alignItems="center">
                <Grid item xs={12}>
                  <Logo></Logo>
                </Grid>
                <Grid item xs={12}><p style={styles.loginToBrutus}>Zaloguj się do systemu Brutus</p></Grid>
                <Grid item xs={12}>
                  <InputBox></InputBox>
                </Grid>
              </Grid>
            );
          }
    }
}
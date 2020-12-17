import React from 'react';
import Grid from '@material-ui/core/Grid';
import InputBox from './InputBox'
//import PrimarySearchAppBar from './NavBar'
export default class HomePage extends React.Component{
    render() {
        {
            return (
              <Grid>
              <Grid item xs={12}>
                <InputBox></InputBox>
              </Grid>
            </Grid>
            );
          }
    }
}
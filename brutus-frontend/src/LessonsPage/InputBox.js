import React from 'react';
import Grid from '@material-ui/core/Grid';
import 'typeface-roboto';
import color from '@material-ui/core/colors/deepOrange';
export default class InputBox extends React.Component{
    borderProperties = {
        bgcolor: color[0],
        borderColor: '#4C00D9',
        m: 20,
        border: 3,
        style: { width: '500px', height: '310px' },
      };
    
    render() {
            return (
                <>
                <Grid container justify="center" alignItems="center">
                   TU BEDZIE PLAN LEKCJI
                </Grid>
                </>
            );
    }
}
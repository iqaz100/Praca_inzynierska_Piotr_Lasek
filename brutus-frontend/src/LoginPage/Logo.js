import React from 'react';
import Icon from '@material-ui/core/Icon';
import Grid from '@material-ui/core/Grid';
import 'typeface-roboto';
import { hexToRgb } from '@material-ui/core/styles';

var styles = {
    header: {
        fontSize: 70,
        fontFamily: 'Helvetica', 
        padding: 5, 
        margin: 0, 
        letterSpacing: 1, 
        color: hexToRgb('#4C00D9'), 
        lineHeight: 0.8
    },
    subHeader: {
        fontSize: 15,
        padding: 8, 
        margin: 0, 
        fontFamily: 'Helvetica', 
        width: 400, 
        color: hexToRgb('#4C00D9'), 
        opacity: 0.66, 
        lineHeight: 0
    }
    
}

export default class Logo extends React.Component{
    render() {
        {
            return (
                <>
                <section style={styles.studentImage}></section>
                <Grid container justify="center" alignItems="center">
                    <Grid item xs={3}>
                        <Icon style={{ fontSize: 100 }}>schoolicon</Icon>
                    </Grid>
                    <Grid item xs={9} >
                    <strong style={styles.header}>Brutus <br/></strong>
                    <strong style={styles.subHeader}>Nowoczesny dziennik elektroniczny</strong>
                    </Grid>
                </Grid>
                
                </>
            );
          }
    }
}
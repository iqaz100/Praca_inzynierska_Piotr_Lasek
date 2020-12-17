import React from 'react';
import Grid from '@material-ui/core/Grid';
import SimpleTable from './GradesTable'
export default class HomePage extends React.Component{
    render() {
        {
            return (
              <Grid container direction="column"justify="center" alignItems="center">
              <Grid item xs={12}>
                <SimpleTable></SimpleTable>
              </Grid>
            </Grid>
            );
          }
    }
}
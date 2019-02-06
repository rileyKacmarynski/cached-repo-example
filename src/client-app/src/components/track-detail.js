import React, { Component } from 'react';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import CircularProgress from '@material-ui/core/CircularProgress';
import { withRouter } from 'react-router-dom';
import styled from 'styled-components';

import { fetchAsync } from '../code/helpers';

const Track = styled.div`
  padding-top: 10px;
  text-align: center;
  h3,
  h5 {
    padding-top: 10px;
  }
`;

export class TrackDetail extends Component {
  state = {
    track: {}
  };

  async componentDidMount() {
    const { id } = this.props.match.params;
    const { value } = await fetchAsync(`track/${id}`);
    this.setState({ track: value });
  }

  fromWhere() {
    if (!this.state.track.trackId) return;
    return this.state.track.fromCache ? 'From Cache' : 'From Database';
  }

  render() {
    return (
      <Track>
        <Grid container spacing={16}>
          <Grid item xs={3} />
          <Grid item xs={6}>
            <Paper>
              {!this.state.track.trackId ? (
                <CircularProgress />
              ) : (
                <>
                  <Typography variant="h3" color="primary">
                    {this.state.track.name}
                  </Typography>
                  <Typography variant="h5" color="primary">
                    {this.state.track.artist}
                  </Typography>
                  <Typography variant="h5" color="primary">
                    {this.state.track.album}
                  </Typography>
                  <Typography variant="h5" color="primary">
                    {this.state.track.genre}
                  </Typography>
                  <Typography variant="h5" color="primary">
                    {this.fromWhere()}
                  </Typography>
                </>
              )}
            </Paper>
          </Grid>
          <Grid item xs={3} />
        </Grid>
      </Track>
    );
  }
}

export default withRouter(TrackDetail);

import React, { Component } from 'react';
import List from '@material-ui/core/List';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';
import CircularProgress from '@material-ui/core/CircularProgress';
import styled from 'styled-components';

import { fetchAsync } from '../code/helpers';
import TrackListItem from './track-list-item';

const TrackList = styled.div`
  padding-top: 10px;
  text-align: center;
  h3 {
    padding-top: 10px;
  }
`;

class TopTracks extends Component {
  state = {
    tracks: []
  };

  async componentDidMount() {
    const res = await fetchAsync('tracks');
    this.setState({ tracks: res.value });
  }

  render() {
    return (
      <TrackList>
        <Grid container spacing={16}>
          <Grid item xs={3} />
          <Grid item xs={6}>
            <Paper>
              <Typography variant="h3" color="primary">
                Top Tracks
              </Typography>
              <div>
                <List>
                  {this.state.tracks.length === 0 ? (
                    <CircularProgress />
                  ) : (
                    this.state.tracks.map(track => (
                      <TrackListItem track={track} key={track.trackId} />
                    ))
                  )}
                </List>
              </div>
            </Paper>
            <Grid item xs={3} />
          </Grid>
        </Grid>
      </TrackList>
    );
  }
}

export default TopTracks;

import React, { Component } from 'react';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import { withRouter } from 'react-router-dom';

import { fetchAsync } from '../code/helpers';

export class TrackDetail extends Component {
  state = {
    track: {}
  };

  async componentDidMount() {
    const { id } = this.props.match.params;
    const { value } = await fetchAsync(`track/${id}`);
    this.setState({ track: value });
  }

  render() {
    return (
      <Paper>
        <Typography variant="h4" color="primary">
          {}
        </Typography>
      </Paper>
    );
  }
}

export default withRouter(TrackDetail);

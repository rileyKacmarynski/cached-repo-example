import React from 'react';
import Icon from '@material-ui/core/Icon';
import SaveAltIcon from '@material-ui/icons/SaveAlt';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import { withRouter } from 'react-router-dom';

const TrackListItem = props => {
  return (
    <ListItem
      button
      onClick={() => props.history.push(`/tracks/${props.track.trackId}`)}
    >
      <ListItemText
        primary={`${props.track.name} (${props.track.score})`}
        secondary={props.track.artist}
      />
      <Icon aria-label="Save">
        <SaveAltIcon color={props.track.fromCache ? 'primary' : 'disabled'} />
      </Icon>
    </ListItem>
  );
};

export default withRouter(TrackListItem);

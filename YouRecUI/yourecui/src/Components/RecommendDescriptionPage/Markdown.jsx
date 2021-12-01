import React from 'react';
import MDEditor from '@uiw/react-md-editor';

export default function MarkDownText(props) {

    return (
        <div className="container">
            <MDEditor.Markdown source={props.text} />
        </div>
    );
}
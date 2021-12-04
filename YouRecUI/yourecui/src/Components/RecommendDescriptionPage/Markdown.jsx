import React from 'react';
import MarkdownPreview from '@uiw/react-markdown-preview';

export default function MDText(props) {

    return (
        <div className="container" style={{ overflowWrap: 'break-word' }}>
            <br />
            <MarkdownPreview source={props.text} />
            <br />
        </div>
    );
}
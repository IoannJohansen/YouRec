import React from 'react';
import MarkdownPreview from '@uiw/react-markdown-preview';

export default function MDText(props) {

    return (
        <div className="container">
            <MarkdownPreview source={props.text} />
        </div>
    );
}